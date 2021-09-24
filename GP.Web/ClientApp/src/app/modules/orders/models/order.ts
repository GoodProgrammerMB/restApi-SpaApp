import { OrderItem } from './order-item';

export interface Order{
  id: number;
  tableNumber: number;
  items: Array<OrderItem>;
  totalAmount: number |null;
}
