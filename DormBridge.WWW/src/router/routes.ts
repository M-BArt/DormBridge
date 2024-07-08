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
    component: () => import('layouts/MainLayout.vue'),
    children: [
      // Dashboard
      { path: '/dashboard', component: () => import('pages/UserPages/dashboardPage.vue') },

      // Help page
      { path: '/help-user', component: () => import('pages/UserPages/helpUserPage.vue') },
      { path: '/help-personnel', component: () => import('pages/PersonnelPages/helpPersonnelPage.vue') },

      // Room management
      { path: '/view-rooms', component: () => import('pages/UserPages/Room Management/viewRoomsPage.vue') },
      { path: '/room-request', component: () => import('pages/UserPages/Room Management/roomRequestPage.vue') },
      { path: '/view-requests-room', component: () => import('pages/UserPages/Room Management/viewRequestsPage.vue') },

      // Maintenance requests
      { path: '/new-maintenance-request', component: () => import('pages/UserPages/Maintenance Requests/newMaintenanceRequestPage.vue') },
      { path: '/view-requests-maintenance', component: () => import('pages/UserPages/Maintenance Requests/viewRequestsPage.vue') },
      { path: '/view-completed-requests', component: () => import('pages/UserPages/Maintenance Requests/viewCompleteRequestsPage.vue') },

      // Settings
      { path: '/update-profile', component: () => import('pages/UserPages/Settings/updateProfilePage.vue') },
      { path: '/change-password', component: () => import('pages/UserPages/Settings/changePasswordPage.vue') },
    ],
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
