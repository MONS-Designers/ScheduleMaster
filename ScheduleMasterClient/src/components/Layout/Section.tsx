import { Card } from 'primereact/card';
import { Outlet } from 'react-router';

const Section = () => {
    return (
        <Card style={{minHeight: '90vh', padding: '0px'}}>
            <Outlet />
        </Card>
    );
};

export default Section;