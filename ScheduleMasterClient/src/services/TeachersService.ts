import axios from 'axios';
import { ITeacherDetailsDTO } from '../types/ITeacherDetailsDTO';

// const API_BASE_URL = import.meta.env.VITE_API_BASE_URL;

const teachersService = {
    getByParametersData: async (managerId: number, teacherDetailsDTO: ITeacherDetailsDTO | null) => {
        let params = '?';
        params += teacherDetailsDTO?.firstName ? `firstName=${teacherDetailsDTO.firstName}&` : ''
        params += teacherDetailsDTO?.lastName ? `lastName=${teacherDetailsDTO.lastName}&` : '';
        params += teacherDetailsDTO?.mail ? `mail=${teacherDetailsDTO.mail}&` : '';
        params += teacherDetailsDTO?.subjects?.length ? `subjects=${teacherDetailsDTO.subjects.join(',')}&` : '';
        params += teacherDetailsDTO?.cellPhone ? `cellPhone=${teacherDetailsDTO.cellPhone}&` : '';
        params += teacherDetailsDTO?.telephone ? `telephone=${teacherDetailsDTO.telephone}` : '';

        try {
            const response = await axios.get(`https://localhost:7093/api/Managers/${managerId}/teachers${params}`);
            return response.data;
        } catch (error) {
            return error;
        }
    },
};

export default teachersService;
