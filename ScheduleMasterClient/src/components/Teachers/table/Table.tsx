import React, { useState } from 'react';
import { DataTable } from 'primereact/datatable';
import { Column } from 'primereact/column';
import { ITeacherDetailsDTO } from '../../../types/ITeacherDetailsDTO';
import { ISubjectDTO } from '../../../types/ISubjectDTO';
import magnusLogo from '../../../assets/magnusLogo.png';
import { validateName, validateTelephone, validateCellPhone, validateEmail } from '../../../utils/validations';
import { emailEditor, firstNameEditor, lastNameEditor, telephoneEditor, cellPhoneEditor, listEditor } from '../../../utils/editors';
import { Button } from 'primereact/button';
import './Table.css';
import { Chip } from 'primereact/chip';

const Table: React.FC<{ teachers: ITeacherDetailsDTO[] }> = ({ teachers }) => {
    const [data, setData] = useState<ITeacherDetailsDTO[]>(teachers);

    const subjectNames = (subjects: ISubjectDTO[]) => {
        return subjects && subjects.length > 0 ? subjects.map((subject) => <Chip key={subject.subjectId} label={subject.subjectName} className='chip'/>) : null;
    };

    const subjectOptions = [
        { label: 'Java', value: 'Java' },
        { label: 'Science', value: 'science' },
        { label: 'History', value: 'history' },
        { label: 'Art', value: 'art' }
    ];

    const handleDelete = (teacherId: number): void => {
        // Open a dialog with a question
    };

    const onRowEditComplete = (e: any) => {
        let _teachers = [...data];
        let { newData, index } = e;

        _teachers[index] = newData;

        setData(_teachers);
        // Simulate saving to the server
    };

    const allowEdit = (rowData: ITeacherDetailsDTO) => {
        if (rowData.telephone && !validateTelephone(rowData.telephone))
            return false;
        if (rowData.cellPhone && !validateCellPhone(rowData.cellPhone))
            return false;
        if (rowData.firstName && !validateName(rowData.firstName))
            return false;
        return validateEmail(rowData.mail);
    };

    return (
        teachers && teachers?.length > 0 && <DataTable value={data} paginator rows={25} editMode="row" dataKey="teacherId" onRowEditComplete={onRowEditComplete}>
            <Column body={(rowData) => <img src={rowData.profileImageURL || magnusLogo || ''} alt={rowData.profileName} className='profileImage' />} />
            <Column field='mail' header='Mail' editor={(options) => emailEditor(options)} />
            <Column sortable field="firstName" header="First Name" editor={(options) => firstNameEditor(options)} />
            <Column sortable field="lastName" header="Last Name" editor={(options) => lastNameEditor(options)} />
            <Column field="telephone" header="Telephone" editor={(options) => telephoneEditor(options)} />
            <Column field="cellPhone" header="Cell Phone" editor={(options) => cellPhoneEditor(options)} />
            <Column body={(rowData) => subjectNames(rowData.subjects)} header="Subjects" editor={(options) => listEditor(options, subjectOptions)} />
            <Column header='Edit' rowEditor={allowEdit} />
            <Column header='Delete' body={(rowData) => (
                <Button label="Delete" icon="pi pi-trash" onClick={() => handleDelete(rowData.teacherId)} severity="danger" />
            )} />
        </DataTable>
        ||
        <div>No data to display</div>
    );
};


export default Table;
