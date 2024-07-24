const importanceLevel = require("./ImportanceLevel");
const mongoose = require("mongoose")
const taskSchcema = new mongoose.Schema({
    title: {
        type: String,
        require: true
    },
    description: {
        type: String,
        default: "No desc."
    },
    finished: {
        type: Boolean,
        default: false
    },
    importanceLevel: {
        type: mongoose.ObjectId,
        required: true,
        ref: importanceLevel
    }
}, {
    timestamps: true
})

module.exports = mongoose.model("Task", taskSchcema)