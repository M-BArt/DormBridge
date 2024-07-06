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
    path: '/admin',
    component: () => import('layouts/MainAdminLayout.vue'),
    children: [{ path: '/profile', component: () => import('pages/UserPages/helpPage.vue') }],
    meta: { requiresAuth: true },
  },

  {
    path: '/personnel',
    component: () => import('layouts/MainPersonnelLayout.vue'),
    children: [{ path: '/asd', component: () => import('pages/IndexPage.vue') }],
    meta: { requiresAuth: true },
  },

  {
    path: '/user',
    component: () => import('layouts/MainUserLayout.vue'),
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
