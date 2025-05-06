
import { Toolbar } from 'primereact/toolbar';
import Logo from '../logoComponent/Logo';
import { Button } from 'primereact/button';
import '../../assets/styles/button.css';
import './Header.css';
import { useNavigate } from 'react-router-dom';

export default function Header() {
    const navigate = useNavigate();

    const startContent = (
        <div className='start-content'>
            <Logo />
            <h2 className='gradient-text'>ScheduleMaster</h2>
        </div>
    );

    const centerContent = (
        <div className="flex flex-wrap align-items-center">
            <Button icon="pi pi-home" text raised rounded aria-label="Home" onClick={()=> navigate('/')} />
            <Button icon="pi pi-calendar-clock" text raised rounded aria-label="Schedule" onClick={()=> navigate('/schedule')} />
            <Button icon="pi pi-users" text raised rounded aria-label="Teachers" onClick={()=>navigate('/teachers')} />
            <Button icon="pi pi-list-check" text raised rounded aria-label="Tasks" onClick={()=>navigate('/tasks')} />
        </div>
    );

    const endContent = (
        <>
             <div className="flex align-items-center gap-2" style={{minWidth: '15vw'}}>
                    <i className="pi pi-user text-2xl" /> Hello user!
            </div> 
        </>
    );

    return (
        <div className="card">
            <Toolbar start={startContent} center={centerContent} end={endContent} className="bg-gray-900 shadow-2 tool-bar"/>
        </div>
    );
}

