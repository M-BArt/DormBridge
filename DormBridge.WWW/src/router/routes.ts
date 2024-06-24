import { RouteRecordRaw } from 'vue-router';

const routes: RouteRecordRaw[] = [
  {
    path: '/',
    component: () => import('layouts/AuthorizationLayout.vue'),
    children: [
      {
        path: '/login',
        component: () => import('pages/AuthorizationPages/LoginPage.vue'),
      },
      {
        path: '/register',
        component: () => import('pages/AuthorizationPages/RegisterPage.vue'),
      },
      {
        path: '/remind',
        component: () => import('pages/AuthorizationPages/RemindPasswordPage.vue'),
      },
    ],
  },

  {
    path: '/main',
    component: () => import('layouts/MainLayout.vue'),
    children: [{ path: '', component: () => import('pages/IndexPage.vue') }],
  },

  {
    path: '/:catchAll(.*)*',
    component: () => import('pages/ErrorNotFound.vue'),
  },
];

export default routes;
