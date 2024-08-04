const mongoose = require("mongoose")
const constraintSchema = new mongoose.Schema({
    employeeId: {
        type: String,
        required: true
    },
    availability: {
        type: [String],
        required: true
    },
    maxHoursPerDay: {
        type: Number,
        required: true
    },
    hourlyConstraints: {
        type: [{
            startTime: String,
            endTime: String
        }]
    }
});

module.exports = mongoose.model("Constraints", constraintSchema)