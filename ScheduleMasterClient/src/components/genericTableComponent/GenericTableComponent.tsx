import React, { useState } from 'react';
import { DataTable } from 'primereact/datatable';
import { Column } from 'primereact/column';
import { InputText } from 'primereact/inputtext';
import { Calendar } from 'primereact/calendar';
import { InputMask } from 'primereact/inputmask';
import { Button } from 'primereact/button';
import { AutoComplete } from 'primereact/autocomplete';
import { GenericTableProps } from '../../types/IGenericTableProps';

const GenericTable = <T extends {}>({ data, columns, onRowEditComplete }: GenericTableProps<T>) => {
    const [editedData, setEditedData] = useState<T[]>(data);
    const [editingRowIndex, setEditingRowIndex] = useState<number | null>(null);
    const [suggestions, setSuggestions] = useState<string[]>([]);

    const onEditorValueChange = (e: any, rowIndex: number, field: keyof T) => {
        const updatedData = [...editedData];
        updatedData[rowIndex] = { ...updatedData[rowIndex], [field]: e.value };
        setEditedData(updatedData);
    };

    const onRowEdit = (rowData: T, rowIndex: number) => {
        setEditingRowIndex(rowIndex);
    };

    const onSave = (rowData: T, rowIndex: number) => {
        // Perform validation here
        if (validateRow(rowData)) {
            onRowEditComplete(rowData);
            setEditingRowIndex(null); // Close editing mode
        } else {
            alert('Validation failed');
        }
    };

    const onCancel = (rowData: T, rowIndex: number) => {
        setEditingRowIndex(null); // Close editing mode
    };

    const validateRow = (rowData: T): boolean => {
        // Implement your validation logic here
        return true; // Return true if valid, false otherwise
    };

    const searchAutocomplete = (event: { query: string }) => {
        // Example: Fetch suggestions based on the query
        const results = ['Option 1', 'Option 2', 'Option 3'].filter((item) =>
            item.toLowerCase().includes(event.query.toLowerCase())
        );
        setSuggestions(results);
    };
    let ind = 0;
    return (
        <DataTable value={editedData} editMode="row" dataKey="id">
            <Column
                key={ind}
                header=""
                body={(rowData, options) => options.rowIndex + 1}
            />
            {columns.map((col, index) => (
                <Column
                    key={ind}
                    field={col.field as string}
                    header={col.header}
                    body={(rowData, options) => {
                        const fieldValue = rowData[col.field];
                        return col.type === 'date' ? (
                            <Calendar
                                value={fieldValue}
                                onChange={(e) => onEditorValueChange(e, options.rowIndex, col.field)}
                            />
                        ) : col.type === 'phone' ? (
                            <InputMask
                                mask="(999) 9999-999"
                                value={fieldValue}
                                onChange={(e) => onEditorValueChange(e, options.rowIndex, col.field)}
                            />
                        ) : col.type === 'autocomplete' ? (
                            <AutoComplete
                                value={fieldValue}
                                suggestions={suggestions}
                                completeMethod={searchAutocomplete}
                                onChange={(e) => onEditorValueChange(e, options.rowIndex, col.field)}
                            />
                        ) : (
                            <InputText
                                value={fieldValue}
                                onChange={(e) => onEditorValueChange(e, options.rowIndex, col.field)}
                            />
                        );
                    }}
                />
            ))}
            <Column
                key={ind++}
                body={(rowData, options) => (
                    editingRowIndex === options.rowIndex ? (
                        <Button
                            label="Save"
                            icon="pi pi-check"
                            onClick={() => onSave(rowData, options.rowIndex)}
                        />
                    ) : (
                        <Button
                            label="Edit"
                            icon="pi pi-pencil"
                            onClick={() => onRowEdit(rowData, options.rowIndex)}
                        />
                    )
                )}
            />
        </DataTable>
    );
};

export default GenericTable;