using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace XXX.Net.Plugins.DingTalk.Utils
{
    public class DingTalkEncryptor
    {
        //private static readonly Charset CHARSET = Charset.forName("utf-8");
        //private static readonly Base64         base64  = new Base64();
        private byte[] aesKey;
        private String token;
        private String corpId;
        /**ask getPaddingBytes key固定长度**/
        private static readonly int AES_ENCODE_KEY_LENGTH = 43;
        /**加密随机字符串字节长度**/
        private static readonly int RANDOM_LENGTH = 16;

        /**
         * 构造函数
         * @param token            钉钉开放平台上，开发者设置的token
         * @param encodingAesKey   钉钉开放台上，开发者设置的EncodingAESKey
         * @param corpId           企业自建应用-事件订阅, 使用appKey
         *                         企业自建应用-注册回调地址, 使用corpId
         *                         第三方企业应用, 使用suiteKey
         *
         * @throws DingTalkEncryptException 执行失败，请查看该异常的错误码和具体的错误信息
         */

        public DingTalkEncryptor(String token, String encodingAesKey,
            String corpId

            )
        {
            if (null == encodingAesKey || encodingAesKey.Length != AES_ENCODE_KEY_LENGTH)
            {
                throw new DingTalkEncryptException(DingTalkEncryptException.AES_KEY_ILLEGAL);
            }
            this.token = token;
            this.corpId = corpId;
            aesKey = Convert.FromBase64String(encodingAesKey + "=");
        }

        /**
         * 将和钉钉开放平台同步的消息体加密,返回加密Map
         */
        public Dictionary<String, String> getEncryptedMap(String plaintext)
        {

            var time = DateTime.Now.Millisecond;
            return getEncryptedMap(plaintext, time);
        }

        /**
         * 将和钉钉开放平台同步的消息体加密,返回加密Map
         * @param plaintext     传递的消息体明文
         * @param timeStamp      时间戳
         * @param nonce           随机字符串
         * @return
         * @throws DingTalkEncryptException
         */
        public Dictionary<String, String> getEncryptedMap(String plaintext, long timeStamp)
        {
            if (null == plaintext)
            {
                throw new DingTalkEncryptException(DingTalkEncryptException.ENCRYPTION_PLAINTEXT_ILLEGAL);
            }
            var nonce = Utils.getRandomStr(RANDOM_LENGTH);
            if (null == nonce)
            {
                throw new DingTalkEncryptException(DingTalkEncryptException.ENCRYPTION_NONCE_ILLEGAL);
            }
            String encrypt = this.encrypt(nonce, plaintext);
            String signature = getSignature(token, timeStamp.ToString(), nonce, encrypt);
            Dictionary<String, String> resultMap = new Dictionary<String, String>();
            resultMap["msg_signature"] = signature;
            resultMap["timeStamp"] = timeStamp.ToString();
            resultMap["nonce"] = nonce;
            resultMap["encrypt"] = encrypt;


            return resultMap;
        }

        /**
         * 密文解密
         * @param msgSignature     签名串
         * @param timeStamp        时间戳
         * @param nonce             随机串
         * @param encryptMsg       密文
         * @return                  解密后的原文
         * @throws DingTalkEncryptException
         */
        public String getDecryptMsg(String msgSignature, String timeStamp, String nonce, String encryptMsg)
        {
            //校验签名
            String signature = getSignature(token, timeStamp, nonce, encryptMsg);
            if (!signature.Equals(msgSignature))
            {
                throw new DingTalkEncryptException(DingTalkEncryptException.COMPUTE_SIGNATURE_ERROR);
            }
            // 解密
            String result = decrypt(encryptMsg);
            return result;
        }


        /*
         * 对明文加密.
         * @param text 需要加密的明文
         * @return 加密后base64编码的字符串
         */
        private String encrypt(String random, String plaintext)
        {
            try
            {
                byte[] randomBytes = System.Text.Encoding.UTF8.GetBytes(random);// random.getBytes(CHARSET);
                byte[] plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plaintext);// plaintext.getBytes(CHARSET);
                byte[] lengthByte = Utils.int2Bytes(plainTextBytes.Length);
                byte[] corpidBytes = System.Text.Encoding.UTF8.GetBytes(corpId);// corpId.getBytes(CHARSET);
                                                                                //MemoryStream byteStream = new MemoryStream();
                var bytestmp = new List<byte>();
                bytestmp.AddRange(randomBytes);
                bytestmp.AddRange(lengthByte);
                bytestmp.AddRange(plainTextBytes);
                bytestmp.AddRange(corpidBytes);
                byte[] padBytes = PKCS7Padding.getPaddingBytes(bytestmp.Count);
                bytestmp.AddRange(padBytes);
                byte[] unencrypted = bytestmp.ToArray();

                RijndaelManaged rDel = new RijndaelManaged();
                rDel.Mode = CipherMode.CBC;
                rDel.Padding = PaddingMode.Zeros;
                rDel.Key = aesKey;
                rDel.IV = aesKey.ToList().Take(16).ToArray();
                ICryptoTransform cTransform = rDel.CreateEncryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(unencrypted, 0, unencrypted.Length);
                return Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }
            catch (Exception e)
            {
                throw new DingTalkEncryptException(DingTalkEncryptException.COMPUTE_ENCRYPT_TEXT_ERROR);
            }
        }

        /*
         * 对密文进行解密.
         * @param text 需要解密的密文
         * @return 解密得到的明文
         */
        private String decrypt(String text)
        {
            byte[] originalArr;
            try
            {
                byte[] toEncryptArray = Convert.FromBase64String(text);
                RijndaelManaged rDel = new RijndaelManaged();
                rDel.Mode = CipherMode.CBC;
                rDel.Padding = PaddingMode.Zeros;
                rDel.Key = aesKey;
                rDel.IV = aesKey.ToList().Take(16).ToArray();
                ICryptoTransform cTransform = rDel.CreateDecryptor();
                originalArr = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                //return System.Text.UTF8Encoding.UTF8.GetString(resultArray);

            }
            catch (Exception e)
            {
                throw new DingTalkEncryptException(DingTalkEncryptException.COMPUTE_DECRYPT_TEXT_ERROR);
            }

            String plainText;
            String fromCorpid;
            try
            {
                // 去除补位字符
                byte[] bytes = PKCS7Padding.removePaddingBytes(originalArr);
                Console.Out.WriteLine("bytes size:" + bytes.Length);

                // 分离16位随机字符串,网络字节序和corpId
                byte[] networkOrder = bytes.Skip(16).Take(4).ToArray();// Arrays.copyOfRange(bytes, 16, 20);
                for (int i = 0; i < 4; i++)
                {
                    Console.Out.WriteLine("networkOrder size:" + (int)networkOrder[i]);
                }

                //Console.Out.WriteLine("bytes plainText:" + networkOrder.Length +" "+JsonSerializer.Serialize(networkOrder));
                int plainTextLegth = Utils.bytes2int(networkOrder);
                Console.Out.WriteLine("bytes size:" + plainTextLegth);

                plainText = System.Text.UTF8Encoding.UTF8.GetString(bytes.Skip(20).Take(plainTextLegth).ToArray()); // new String(Arrays.copyOfRange(bytes, 20, 20 + plainTextLegth), CHARSET);
                fromCorpid = System.Text.UTF8Encoding.UTF8.GetString(bytes.Skip(20 + plainTextLegth).ToArray()); //new String(Arrays.copyOfRange(bytes, 20 + plainTextLegth, bytes.length), CHARSET);
                Console.Out.WriteLine("bytes plainText:" + plainText);

            }
            catch (Exception e)
            {
                throw new DingTalkEncryptException(DingTalkEncryptException.COMPUTE_DECRYPT_TEXT_LENGTH_ERROR);
            }
            Console.Out.WriteLine(fromCorpid + "=====" + corpId);


            // corpid不相同的情况
            if (!fromCorpid.Equals(corpId))
            {
                throw new DingTalkEncryptException(DingTalkEncryptException.COMPUTE_DECRYPT_TEXT_CORPID_ERROR);
            }
            return plainText;
        }

        /**
         * 数字签名
         * @param token         isv token
         * @param timestamp     时间戳
         * @param nonce          随机串
         * @param encrypt       加密文本
         * @return
         * @throws DingTalkEncryptException
         */
        public String getSignature(String token, String timestamp, String nonce, String encrypt)
        {
            try
            {
                Console.Out.WriteLine(encrypt);

                String[] array = new String[] { token, timestamp, nonce, encrypt };
                Array.Sort(array, StringComparer.Ordinal);
                //var tmparray = array.ToList();
                //tmparray.Sort(new JavaStringComper());
                //array = tmparray.ToArray();
                //Console.Out.WriteLine("array:"+JsonSerializer.Serialize(array));
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < 4; i++)
                {
                    sb.Append(array[i]);
                }
                String str = sb.ToString();
                Console.Out.WriteLine(str);
                //MessageDigest md = MessageDigest.getInstance("SHA-1");
                //md.update(str.getBytes());
                //byte[] digest = md.digest();
                System.Security.Cryptography.SHA1 hash = System.Security.Cryptography.SHA1.Create();
                System.Text.Encoding encoder = System.Text.Encoding.ASCII;
                byte[] combined = encoder.GetBytes(str);
                //sbyte[] myByte = new sbyte[]
                //byte[] mySByte = new byte[myByte.Length];



                //for (int i = 0; i < myByte.Length; i++)

                //{

                //    if (myByte[i] > 127)

                //        mySByte[i] = (sbyte)(myByte[i] - 256);

                //    else

                //        mySByte[i] = (sbyte)myByte[i];

                //}

                byte[] digest = hash.ComputeHash(combined);
                StringBuilder hexstr = new StringBuilder();
                String shaHex = "";
                for (int i = 0; i < digest.Length; i++)
                {
                    shaHex = ((int)digest[i]).ToString("x");// Integer.toHexString(digest[i] & 0xFF);
                    if (shaHex.Length < 2)
                    {
                        hexstr.Append(0);
                    }
                    hexstr.Append(shaHex);
                }
                return hexstr.ToString();
            }
            catch (Exception e)
            {
                throw new DingTalkEncryptException(DingTalkEncryptException.COMPUTE_SIGNATURE_ERROR);
            }
        }
    }



}
