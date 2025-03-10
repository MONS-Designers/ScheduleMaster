import React, { useState } from 'react';
import { DataTable } from 'primereact/datatable';
import { Column } from 'primereact/column';
import { Button } from 'primereact/button';
import { ITeacherDetailsDTO } from '../../../types/ITeacherDetailsDTO';
import { ISubjectDTO } from '../../../types/ISubjectDTO';
import magnusLogo from '../../../assets/magnusLogo.png'
const Table: React.FC<{ teachers: ITeacherDetailsDTO[] | null }> = ({ teachers }) => {
    const [selectedRowData, setSelectedRowData] = useState<ITeacherDetailsDTO | null>(null);
    
    if (!teachers) return null;
    const subjectNames = (subjects: ISubjectDTO[] | null) => {
        return subjects ? subjects.map(subject => subject.subjectName).join(', ') : '';
    };

    const handleEdit = (rowData: any): void => {
        // Open edit form with teacher data
        setSelectedRowData(rowData);
    }

    const handleDelete = (teacherId: number): void => {
        // Open a dialog with the question
    }

    return (
        <DataTable value={teachers} paginator rows={25}>
            <Column body={(rowData) => <img src={rowData.profileImageURL || magnusLogo || ''} alt={rowData.profileName} style={{ width: '50px', height: '50px' }} />} />
            <Column field='mail' header='Mail' />
            <Column sortable field="firstName" header="First Name" />
            <Column sortable field="lastName" header="Last Name" />
            <Column field="telephone" header="Telephone" />
            <Column field="cellPhone" header="Cell Phone" />
            <Column body={(rowData) => subjectNames(rowData.subjects)} header="Subjects" />
            <Column header='Edit' body={(rowData) => (
                <Button label="Edit" icon="pi pi-pencil" onClick={() => handleEdit(rowData.teacherId)} />
            )} />
            <Column header='Delete' body={(rowData) => (
                <Button label="Delete" icon="pi pi-trash" onClick={() => handleDelete(rowData.teacherId)} className="p-button-danger" severity="danger" />
            )} />
        </DataTable>
    );
};

export default Table;
