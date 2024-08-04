const mongoose = require("mongoose")
const subjectSchcema = new mongoose.Schema({
    id: {
        type:mongoose.Schema.ObjectId,
        immutable: true 
    },
    name: {
        type: String,
        required:true
    },
    required: {
        type: Boolean,
        required:true
    },
    hours: {
        type: Number,
        required: true,
    }
}, {
   
})

module.exports = mongoose.model("Subject", subjectSchcema)