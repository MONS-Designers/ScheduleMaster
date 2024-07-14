import { useContext } from "react";
import { Route, Routes } from "react-router-dom";


import TeacherTable from "./TeacherTable";

const AppRoutes = () => {
  
  return (
    <Routes>
      {/* <Route path="/" element={<Login />}></Route> */}
      <Route path="/" element={<TeacherTable />}></Route>
    </Routes>
  );
};

export default AppRoutes;
