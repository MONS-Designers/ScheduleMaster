import { TableColumn } from './ITableColumn';

export interface GenericTableProps<T> {
    data: T[];
    columns: TableColumn<T>[];
    onRowEditComplete: (data: T) => void;
}