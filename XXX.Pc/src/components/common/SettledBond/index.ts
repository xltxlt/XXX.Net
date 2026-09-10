interface PageDetail {
    title?: string;
    payAmount?: string | number;
    description?: string;
}
interface PaymentOption {
    name: string;
    value: string;
}
export type {PageDetail,PaymentOption}