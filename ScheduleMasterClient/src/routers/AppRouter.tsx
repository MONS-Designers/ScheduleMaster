import { Routes, Route } from 'react-router';
import Home from '../pages/Home';
import TeachersManagement from '../pages/TeachersManagement';
import { Layout } from '../components/Layout/Layout';
import TasksManagement from '../pages/TasksManagement';
import ScheduleManagement from '../pages/ScheduleManagement';

const AppRouter = () => {
    return (
        <Routes>
            <Route path='/' element={<Layout />}>
                <Route path="/" element={<Home />} />
                <Route path="/schedule" element={<ScheduleManagement />} />
                <Route path="/teachers" element={<TeachersManagement />} />
                <Route path="/tasks" element={<div><TasksManagement /></div>} />
            </Route>
        </Routes>
    );
};

export default AppRouter;