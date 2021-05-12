import myaxios from '@/utils/myaxios'
const qs = require("querystring");
export default{
    getCommentListByDiscussId(discussId)
    {
        return myaxios({
            url:`/Comment/GetCommentListByDiscussId?discussId=${discussId}`,
            method:'get'
        })
    },
    addComment(commentData)
    {
        return myaxios({
            url:`/Comment/AddComment`,
            method:'post',
            data:commentData
        })
    }
}