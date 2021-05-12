import Vue from 'vue'
import VueRouter from 'vue-router'
import Layout from '@/components/Layout.vue'
import studentInfo from '../views/student/studentInfo.vue'
import studentCurriculum from '../views/student/studentCurriculum.vue'
import choiceCurriculum from '../views/student/choiceCurriculum.vue'
import approvalCurriculum from '../views/teacher/approvalCurriculum.vue'
import teacherCurriculum from '../views/teacher/teacherCurriculum.vue'
import allWork from '../views/pub/allWork.vue'
import fileInfo from '../views/pub/fileInfo.vue'
import index from '../views/pub/index.vue'
import login from '../views/login.vue'
import register from '../views/register.vue'
import commentInfo from '@/views/pub/commentInfo'
import reset_password from '../views/reset_password.vue'
import approvalWork from '@/views/teacher/approvalWork'
import studentWork from '@/views/student/studentWork'
import version from '@/views/version'
import examinationInfo from '@/views/pub/examinationInfo'
import addExamination from '@/views/teacher/addExamination'
import imageInfo from '@/views/pub/imageInfo'
import install from '@/views/install'
import studentAccount from '@/views/student/studentAccount'
Vue.use(VueRouter)

const routes = [{
        path: '/reset_password',
        name: 'reset_password',
        component: reset_password
    },
    {
        path: '/login',
        name: 'login',
        component: login
    },
    {
        path: '/register',
        name: 'register',
        component: register
    },
    {
        path: '/',
        name: 'Layout',
        component: Layout,
        redirect: "/index",
        children: [{
                path: "/studentInfo",
                name: "studentInfo",
                component: studentInfo
            },
            {
                path: '/studentCurriculum',
                name: 'studentCurriculum',
                component: studentCurriculum
            },
            {
                path: '/choiceCurriculum',
                name: 'choiceCurriculum',
                component: choiceCurriculum
            },
            {
                path: '/approvalCurriculum',
                name: 'approvalCurriculum',
                component: approvalCurriculum
            },
            {
                path: '/teacherCurriculum',
                name: 'teacherCurriculum',
                component: teacherCurriculum
            },
            {
                path: '/allWork',
                name: 'allWork',
                component: allWork
            },
            {
                path: '/fileInfo',
                name: 'fileInfo',
                component: fileInfo
            },
            {
                path: '/index',
                name: 'index',
                component: index
            },
            {
                path: '/commentInfo',
                name: 'commentInfo',
                component: commentInfo
            },
            {
                path: '/approvalWork',
                name: 'approvalWork',
                component: approvalWork
            },
            {
                path: '/studentWork',
                name: 'studentWork',
                component: studentWork
            },
            {
                path: '/version',
                name: 'version',
                component: version
            },
            {
                path: '/examinationInfo',
                name: 'examinationInfo',
                component: examinationInfo
            },
            {
                path: '/addExamination',
                name: 'addExamination',
                component: addExamination
            },
            {
                path: '/imageInfo',
                name: 'imageInfo',
                component: imageInfo
            },
            {
                path: '/install',
                name: 'install',
                component: install
            },
            {
                path: '/studentAccount',
                name: 'studentAccount',
                component: studentAccount
            },
        ]
    }
]

const router = new VueRouter({
    mode: 'history',
    base: process.env.BASE_URL,
    routes: routes,
    scrollBehavior(to, from, savedPosition) {
        return { x: 0, y: 0 }
    }

})

export default router