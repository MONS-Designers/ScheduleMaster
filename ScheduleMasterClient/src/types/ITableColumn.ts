export interface TableColumn<T> {
    field: keyof T;
    header: string;
    type?: 'text' | 'date' | 'phone' | 'autocomplete';
    editor?: (props: any) => JSX.Element;
}