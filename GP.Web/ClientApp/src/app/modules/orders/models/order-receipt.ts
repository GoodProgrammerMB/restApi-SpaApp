export interface OrderReceipt{
  id: number;
  tableNumber: number;
  totalAmount: number |null;
  orderItems: string;
}
