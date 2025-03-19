import { useEffect, useState } from 'react';
import teachersService from '../services/TeachersService';
import { ITeacherDetailsDTO } from '../types/ITeacherDetailsDTO';
import Table from '../components/Teachers/table/Table';
import { Button } from 'primereact/button';
import '../assets/styles/button.css';

const TeachersManagement = () => {
    const [data, setData] = useState<ITeacherDetailsDTO[] | null>(null);
    const [loading, setLoading] = useState<boolean>(true);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        fetchData();
    }, []);

    const fetchData = async () => {
        try {
            const result = await teachersService.getByParametersData(1, null);
            setData(result);
        } catch (err: any) {
            setError(err);
        } finally {
            setLoading(false);
        }
    };

    return (
        <div>
            <h1 className='gradient-text'>Teachers</h1>
            {loading && <Button text rounded raised icon="pi pi-spin pi-refresh" onClick={() => fetchData()} />
            || <Button text rounded raised icon="pi pi-refresh" onClick={() => fetchData()} />}
            {(loading  && <Button text rounded raised icon="pi pi-spin pi-refresh" onClick={() => fetchData()} /> && <div>Loading...</div>)
            || (error && <div>Error: {error}</div>)
            || (data && <Table teachers={data} />)}
        </div>
    );

};

export default TeachersManagement;