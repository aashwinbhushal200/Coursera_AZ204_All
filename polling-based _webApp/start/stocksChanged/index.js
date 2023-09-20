//Every updated stock is provided to the arguments array along with a target property set to updated.
//The value of the target property is used on the client when listening for specific messages broadcast by SignalR.
module.exports = async function (context, documents) {
    const updates = documents.map(stock => ({
        target: 'updated',
        arguments: [stock]
    }));

    context.bindings.signalRMessages = updates;
    context.done();
}