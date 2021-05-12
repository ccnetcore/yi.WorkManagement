import myaxios from '@/utils/myaxios'
const qs = require("querystring");
export default {
    login(formData) {
        const token = localStorage.getItem("token")
        return myaxios({
            url: `/Account/Login`,
            method: 'post',
            data: qs.stringify({
                username: formData.username,
                pwd: formData.pwd,
                token: token
            })
        })
    },
    logOff() {
        return myaxios({
            url: '/Account/LogOff',
            method: 'post'
        })
    },
    logged() {
        return myaxios({
            url: '/Account/Logged',
            method: 'post'
        })
    },
    VerificationCodeImage() {
        return myaxios({
            url: '/VerificationCodeImage',
            method: 'get'
        })
    },
    PostcheckCode(checkCode) {
        return myaxios({
            url: '/verification/check',
            method: 'post',
            data: qs.stringify({
                code: JSON.stringify(checkCode)
            })

        })
    },
    register(form) {
        return myaxios({
            url: '/Account/register',
            method: 'post',
            data: qs.stringify({
                mail: form.mail,
                username: form.username,
                pwd: form.pwd,
                code: form.code,
            })

        })
    },
    resetPwd(form) {
        return myaxios({
            url: '/Account/resetPwd',
            method: 'post',
            data: qs.stringify({
                mail: form.mail,
                pwd: form.pwd,
                code: form.code,
            })

        })
    }
}