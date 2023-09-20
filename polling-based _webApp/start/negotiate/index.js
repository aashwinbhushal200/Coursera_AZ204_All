//added after SignalR is added
module.exports = async function (context, req, connectionInfo) {
    context.res.body = connectionInfo;
};