import { useEffect, useState } from 'react';
import teachersService from '../services/TeachersService';
import { ITeacherDetailsDTO } from '../types/ITeacherDetailsDTO';
import Table from '../components/Teachers/table/Table';

const TeachersManagement = () => {
    const [data, setData] = useState<ITeacherDetailsDTO[] | null>(null);
    const [loading, setLoading] = useState<boolean>(true);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
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

        fetchData();
    }, []);

    return (
        <div>
            <h1 className='gradient-text'>Teachers</h1>
            {(loading && <div>Loading...</div>)
            || (error && <div>Error: {error}</div>)
            || (data && <Table teachers={data} />)}
        </div>
    );

};

export default TeachersManagement;