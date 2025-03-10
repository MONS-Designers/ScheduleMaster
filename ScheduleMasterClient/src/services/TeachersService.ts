import axios from 'axios';
import { ITeacherDetailsDTO } from '../types/ITeacherDetailsDTO';

// const API_BASE_URL = import.meta.env.VITE_API_BASE_URL;

const teachersService = {
    getByParametersData: async (managerId: number, teacherDetailsDTO: ITeacherDetailsDTO|null) => {
        try {
            const response = await axios.get(`https://localhost:7093/api/Managers/${managerId}/teachers` );
            return response.data;
        } catch (error) {
            return error;
        }
    },
};

export default teachersService;
