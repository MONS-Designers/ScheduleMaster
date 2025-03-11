import React, {useEffect, useState} from 'react';
// import GenericTable from '../components/genericTableComponent/GenericTableComponent'
// import { TableColumn } from '../types/ITableColumn';
import teachersService from '../services/TeachersService';
import { ITeacherDetailsDTO } from '../types/ITeacherDetailsDTO';
import Table from '../components/Teachers/table/Table';

const TeachersManagement = () => {
    const [data, setData] = useState<ITeacherDetailsDTO[] | null>(null);
    const [loading, setLoading] = useState<boolean>(true);
    const [error, setError] = useState<string|null>(null);

    // const columns: TableColumn<any>[] = [
    //     { field: 'firstName', header: 'Name', type: 'text' },
    //     { field: 'cellPhone', header: 'Phone', type: 'phone' },
    //     { field: 'autocomplete', header: 'Subjects', type: 'autocomplete' }
    // ];

    // const handleRowEditComplete = (data: any) => {
    //     console.log('Row edited:', data);
    // };

    useEffect(() => {
        const fetchData = async () => {
          try {
            const result = await teachersService.getByParametersData(1, null);
            setData(result);
          } catch (err:any) {
            setError(err);
          } finally {
            setLoading(false);
          }
        };
    
        fetchData();
      }, []);
    
      if (loading) return <div>Loading...</div>;
      if (error) return <div>Error: {error}</div>;

    // const onRowEditComplete = (rowData: any) => {
    //   console.log('Row edited:', rowData);
    //   // כאן תוכל להוסיף לוגיקה לשמירת השינוי
    // };

    // const handleAutocompleteChange = (event) => {
    //   setSelectedSuggestion(event.value);
    //   // כאן תוכל להוסיף לוגיקה כדי לעדכן את השורה המתאימה
    // };

    // const handleAutocompleteSearch = (event) => {
    //   // כאן תוכל להוסיף לוגיקה לחיפוש הצעות
    //   setFilteredSuggestions([
    //       { name: 'Suggestion 1' },
    //       { name: 'Suggestion 2' },
    //       { name: 'Suggestion 3' }
    //   ]);
    // };

    return (
        <div>
            <h1 className='gradient-text'>Teachers</h1>
            {/* <GenericTable
                data={data || []}
                columns={columns}
                onRowEditComplete={handleRowEditComplete}
            /> */}
            {data && <Table teachers={data}/>}
        </div>
    );

};

export default TeachersManagement;