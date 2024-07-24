
const express =require("express")
const router=express.Router()

const taskController=require(`../../controllers/taskController`)

// const verifyJWT=require("../middleware/verityJWT")
// router.use(verifyJWT)

router.post("/",taskController.createNewTask)
router.get("/:title/:description/:finished/:importanceLevel/:endDate/",taskController.getTaskByParameters)
router.put(`/`,taskController.updateTask)
router.delete(`/`,taskController.deleteTask)

module.exports=router