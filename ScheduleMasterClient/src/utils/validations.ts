export const validateName = (name: string): boolean => {
    return /^[א-תa-zA-Z]{2,}$/.test(name);
};

export const validateTelephone = (telephone: string): boolean => {
    return /^0[2-9]\d{8}$/.test(telephone);
};

export const validateCellPhone = (cellPhone: string): boolean => {
    return /^05\d{8}$/.test(cellPhone);
};

export const validateEmail = (email: string): boolean => {
    return /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/.test(email);
};
