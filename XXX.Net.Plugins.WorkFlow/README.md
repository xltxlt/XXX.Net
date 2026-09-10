## 工作流程定义
{
  "Id": "HelloWorld",
  "Version": 1,
  "Steps": [
    {
      "Id": "Hello",
      "StepType": "MyApp.HelloWorld, MyApp",
      "NextStepId": "Bye"
    },        
    {
      "Id": "Bye",
      "StepType": "MyApp.GoodbyeWorld, MyApp"
    }
  ]
}
## 步骤直接传递数据
{
  "Id": "AddWorkflow",
  "Version": 1,
  "DataType": "MyApp.MyDataClass, MyApp",
  "Steps": [
    {
      "Id": "Add",
      "StepType": "MyApp.AddNumbers, MyApp",
      "NextStepId": "ShowResult",
      //输入
      "Inputs": { 
          "Input1": "data.Value1",
          "Input2": "data.Value2" 
       },
       //输出
      "Outputs": { 
          "Answer": "step.Output" 
      }
    },    
    {
      "Id": "ShowResult",
      "StepType": "MyApp.CustomMessage, MyApp",
      "Inputs": { 
          "Message": "\"The answer is \" + data.Answer" 
       }
    }
  ]
}