import myaxios from '@/utils/myaxios'
const qs = require("querystring");
export default{
    getDiscussListByCurriculumId(curriculumId)
    {
        return myaxios({
            url:`/Discuss/getDiscussListByCurriculumId?curriculumId=${curriculumId}`,
            method:'get'
        })
    },
    // addDiscuss(discussData)
    // {
    //     return myaxios({
    //         url:`/Discuss/AddDiscuss`,
    //         method:'post',
    //         data:qs.stringify({
    //             curriculum_id:discussData.curriculum_id,
    //             discuss_title: discussData.discuss_title,
    //             discuss_content:discussData.discuss_content,
    //         }) 
    //     })
    // }
    addDiscuss(discussData)
    {
        return myaxios({
            url:`/Discuss/AddDiscuss`,
            method:'post',
            data:discussData
        })
    },
    getDiscussById(id)
    {
        return myaxios({
            url:`/Discuss/GetDiscussById?id=${id}`,
            method:'get'
        })
    }
}