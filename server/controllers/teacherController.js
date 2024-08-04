
const Teacher = require(`../src/models/Teacher`)

const getAllTeachers=async (req,res)=>{
    const arrTeachers =   await Teacher.find().exec()
}
module.exports = {
    getAllTeachers
 
}