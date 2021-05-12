import router from './router/index'
import accountAPI from '@/api/account'
router.beforeEach((to, from, next) => {
    const logged = localStorage.getItem("logged") //获取是否登入
    if (!logged) { //如果没有登入
        if (to.path == '/login' || to.path == '/register' || to.path == '/reset_password') {
            next()
        } else {
            next({ path: '/login' })
        }
    } else { //如果已经登入，就要询问后端会话是否存在
        accountAPI.logged().then(response => {
            const resp = response.data;
            if (resp.flag) { //如果后端会话也存在，那就不管
                next()
            } else { //如果后端会话不存在，清除前端存储并且跳转到登入界面
                localStorage.clear()
                alert("登入已超时，请重新登入")
                next({ path: '/login' })
            }
        })
    }
})