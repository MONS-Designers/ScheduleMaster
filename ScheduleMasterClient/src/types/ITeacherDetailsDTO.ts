import { ISubjectDTO } from './ISubjectDTO';

export interface ITeacherDetailsDTO {
    teacherId: number;
    mail: string;
    firstName: string | null;
    lastName: string | null;
    telephone: string | null;
    cellPhone: string | null;
    profileImageURL: string | null;
    profileName: string | null;
    subjects: ISubjectDTO[] | null;
};