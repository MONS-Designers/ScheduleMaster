import { Routes, Route } from 'react-router';
import Home from '../pages/Home';
import TeachersManagement from '../pages/TeachersManagement';

const AppRouter = () => {
    return (
        <Routes>
            <Route path="/" element={< Home />} />
            <Route path="/teachers" element={< TeachersManagement />} />
        </Routes>
    );
};

export default AppRouter;