import { createRouter, createWebHistory } from 'vue-router';

const routes = [
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
    children: [{ path: '/asd', component: () => import('pages/IndexPage.vue') }],
    meta: { requiresAuth: true },
  },

  {
    path: '/:catchAll(.*)*',
    component: () => import('pages/ErrorNotFound.vue'),
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

router.beforeEach((to, from, next) => {
  const token = localStorage.getItem('token');
  if (to.matched.some((record) => record.meta.requiresAuth) && !token) {
    next({ name: 'login' });
  } else {
    next();
  }
});

export default routes;
