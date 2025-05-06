import { useState } from 'react';
import { Toolbar } from 'primereact/toolbar';
import Logo from '../logoComponent/Logo';
import '../../assets/styles/button.css';
import './Header.css';
import { useNavigate } from 'react-router-dom';
import { TabMenu } from 'primereact/tabmenu';

export default function Header() {
    const navigate = useNavigate();

    const [activeIndex, setActiveIndex] = useState(0);

    const menuItems = [
        { label: 'Home', icon: 'pi pi-home', command: () => navigate('/') },
        { label: 'Schedule', icon: 'pi pi-calendar-clock', command: () => navigate('/schedule') },
        { label: 'Teachers', icon: 'pi pi-users', command: () => navigate('/teachers') },
        { label: 'Tasks', icon: 'pi pi-list-check', command: () => navigate('/tasks') },
    ];

    const startContent = (
        <div className='start-content'>
            <Logo />
            <h2 className='gradient-text'>ScheduleMaster</h2>
        </div>
    );

    const centerContent = (
        <TabMenu
            model={menuItems}
            activeIndex={activeIndex}
            onTabChange={(e) => {
                setActiveIndex(e.index);
                menuItems[e.index].command?.();
            }}
        />
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

