import { Card } from 'primereact/card';
import { Outlet } from 'react-router';

const Section = () => {
    return (
        <Card style={{minHeight: '80vh'}}>
            <Outlet />
        </Card>
    );
};

export default Section;