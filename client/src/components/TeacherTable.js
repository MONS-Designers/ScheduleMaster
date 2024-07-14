import React, { useEffect, useState } from 'react';
import { DataTable } from 'primereact/datatable';
import { InputText } from 'primereact/inputtext';
import { Column } from 'primereact/column';
import { InputMask } from 'primereact/inputmask';

const TeacherTable = () => {
    const [products, setProducts] = useState([]);

    useEffect(() => {
        setProducts([{
            id: 2,
            firstName: "sara",
            lastName:"ochayon",
            subjects:[],
            phone:"0527676767",
          
        },
        {
            id: 2,
            firstName: "nomi",
            lastName:"nomi",
            subjects:[],
            phone:"0527674747",
          
        }]);
    }, []);

    const onRowEditComplete = (e) => {
        let _products = [...products];
        let { newData, index } = e;
        _products[index] = newData;
        setProducts(_products);
    };

    const textEditor = (options) => {
        return <InputText type="text" value={options.value} onChange={(e) => options.editorCallback(e.target.value)} />;
    };

    const PhoneEditor = (props) => {
        return (
            <InputMask
                id="phone"
                mask="999-999-9999"
                placeholder={props.value}
                value={props.value}
                onChange={(e) => props.editorCallback(e.value)}
            />
        );
    };
    const allowEdit = (rowData) => {
        return true;
    };
    return (
        <DataTable value={products} editMode="row" dataKey="id" onRowEditComplete={onRowEditComplete} tableStyle={{ minWidth: '50rem' }}>
            <Column field="id" header="תעודת זהות"  style={{ width: '20%' }}></Column>
            <Column field="firstName" header="שם פרטי" editor={(options) => textEditor(options)} style={{ width: '20%' }}></Column>
            <Column field="lastName" header="שם משפחה" editor={(options) => textEditor(options)} style={{ width: '20%' }}></Column>
            <Column field="phone" header="פלאפון" editor={(props) => PhoneEditor(props)}></Column>
            <Column rowEditor={allowEdit} headerStyle={{ width: '10%', minWidth: '8rem' }} bodyStyle={{ textAlign: 'center' }}></Column>
        </DataTable>
    );
};

export default TeacherTable;