
const Task = require(`../src/models/Task`)

///////////////////////////////////////////////////////////////////////////

const createNewTask = async (req, res) => {
    const { title, description, importanceLevel } = req.body

    if (!title || !importanceLevel) {
        return res.status(400).json({ message: 'Invalid input data' })
    }

    const task = await Task.create({ title, description, importanceLevel })

    if (task)
        return res.status(201).json({ message: 'new Task created!' })
    return res.status(400).json({ message: 'Invalid Task!' })
}

///////////////////////////////////////////////////////////////////////////

const updateTask = async (req, res) => {
    const { _id, title, description, finished, importanceLevel } = req.body

    if (!_id)
        return res.status(400).json({ message: 'Invalid input data' })

    const task = await Task.findOne({ _id: req._id }).exec()

    if (!task)
        return res.status(404).json({ message: 'No task found' })

    task.title = title || task.title
    task.description = description || task.description
    task.finished = finished || task.finished
    task.importanceLevel = importanceLevel || task.importanceLevel

    const updateTask = await task.save()

    return res.status(200).json(`${updateTask._id} updated`)
}

///////////////////////////////////////////////////////////////////////////

const getTaskByParameters = async (req, res) => {
console.log("getTaskByParameters");
    const { title, description, finished, importanceLevel } = req.params

    const conditions = {};
    if (title) {
        conditions.title = title;
    }
    if (description) {
        conditions.description = description;
    }
    if (finished !== undefined) {
        conditions.finished = finished;
    }
    if (importanceLevel) {
        conditions.importanceLevel = importanceLevel;
    }

    const arrTasks = await Task.find(conditions).exec()

    if (!arrTasks?.length)
        return res.status(204).json({ message: 'Task not found' })

    return res.status(200).json(arrCarts)
}

///////////////////////////////////////////////////////////////////////////

const deleteTask = async (req, res) => {

    const { _id } = req.body

    const task = await Task.findById(_id).exec()

    if (!task)
        return res.status(404).json({ message: 'Task not found' })

    const result = await Task.deleteOne(task)

    return res.status(200).json(`Task deleted`)
}

///////////////////////////////////////////////////////////////////////////

module.exports = {

    createNewTask,

    updateTask,

    getTaskByParameters,

    deleteTask

}