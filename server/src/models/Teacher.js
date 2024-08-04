const subject = require("./Subject")
const constraint = require("./Constraint")
const mongoose = require("mongoose")
const teacherSchcema = new mongoose.Schema({
    id: {
        type:String,
        unique: true,
        required: true
    },
    firstName: {
        type: String,
        default: "No desc."
    },
    lastName: {
        type: String,
        default: "No desc."
    },
    // subjects: {
    //     type: [subject],
      
    // },
    // constraints: {
    //     type: [constraint],
    // },
    phone: {
        type:String,
        required: true,
    },
    email: {
        type:String,
        required: true,
    },
   available: {
        type:Boolean,
        required: true,
    },
    diploma: {
        type:String,
        required: true,
    }
}, {
   
})

module.exports = mongoose.model("Teacher", teacherSchcema)