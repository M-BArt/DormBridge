<template>
  <q-layout view="lHr lpR lfr">
    <q-header elevated class="text-white asd q-ma-sm">
      <q-toolbar>
        <q-btn dense flat round icon="menu" @click="toggleLeftDrawer" />
        <q-icon v-if="isAdmin || isUser" @click="goToUserHelp" class="q-mr-sm" name="help_outline" size="2em" />
        <q-icon v-if="isPersonnel" @click="goToPersonnelHelp" class="q-mr-sm" name="help_outline" size="2em" />
        <q-toolbar-title class="flex flex-center">
          <p class="text-subtitle1 q-ma-none">{{ userRole }} Account</p>
        </q-toolbar-title>
        <q-icon v-if="isAdmin" @click="goToPersonnelHelp" class="q-mr-sm" name="help_outline" size="2em" />
        <q-icon class="q-mr-sm" name="notifications_none" size="2em" />
        <q-avatar class="q-ma-none" size="35px">
          <img src="/icons/User.png" />
        </q-avatar>
        <q-btn v-if="isAdmin" dense flat round icon="menu" @click="toggleRightDrawer" />
      </q-toolbar>
    </q-header>

    <!-- Left Drawer for Users and Admin -->
    <q-drawer :width="325" show-if-above v-model="leftDrawerOpen" side="left" class="asd flex justify-center items-center" v-if="isUser || isAdmin">
      <q-card class="asd flex flex-center no-shadow self-start">
        <q-card class="asd flex flex-center justify-evently no-shadow q-pa-none q-mt-md" style="width: 100%">
          <img style="width: 65px" src="/icons/DormBridge.png" />
          <h4 class="q-pa-none q-ma-md" style="color: white">DormBridge</h4>
        </q-card>
        <q-scroll-area :thumb-style="thumbStyle" :bar-style="barStyle" style="height: 70vh; width: 100%">
          <MenuPanel :menuItems="menuItems" />
        </q-scroll-area>
      </q-card>

      <q-card class="asd flex flex-center no-shadow self-end">
        <p style="color: white">© 2024 DormBridge. All rights reserved.</p>
        <p style="color: white">Designed by Bartosz Mroczkowski</p>
      </q-card>
    </q-drawer>

    <!-- Left Drawer for Personnel -->
    <q-drawer :width="325" show-if-above v-model="leftDrawerOpen" side="left" class="asd flex justify-center items-center" v-if="isPersonnel">
      <q-card class="asd flex flex-center no-shadow self-start">
        <q-card class="asd flex flex-center justify-evently no-shadow q-pa-none q-mt-md" style="width: 100%">
          <img style="width: 65px" src="/icons/DormBridge.png" />
          <h4 class="q-pa-none q-ma-md" style="color: white">DormBridge</h4>
        </q-card>
        <q-scroll-area :thumb-style="thumbStyle" :bar-style="barStyle" style="height: 70vh; width: 100%">
          <MenuPanel :menuItems="personnelMenuItems" />
        </q-scroll-area>
      </q-card>

      <q-card class="asd flex flex-center no-shadow self-end">
        <p style="color: white">© 2024 DormBridge. All rights reserved.</p>
        <p style="color: white">Designed by Bartosz Mroczkowski</p>
      </q-card>
    </q-drawer>

    <!-- Right Drawer for Admin -->
    <q-drawer :width="325" show-if-above v-model="rightDrawerOpen" side="right" class="asd flex justify-center items-center" v-if="isAdmin">
      <q-card class="asd flex flex-center no-shadow self-start">
        <q-card class="asd flex flex-center justify-evently no-shadow q-pa-none q-mt-md" style="width: 100%">
          <h4 class="q-pa-none q-ma-md" style="color: white">Personnel Panel</h4>
        </q-card>
        <q-scroll-area :thumb-style="thumbStyle" :bar-style="barStyle" style="height: 70vh; width: 100%">
          <MenuPanel :menuItems="personnelMenuItems" />
        </q-scroll-area>
      </q-card>
    </q-drawer>

    <q-page-container class="q-ma-none q-pa-none">
      <router-view />
    </q-page-container>
  </q-layout>
</template>

<script setup lang="ts">
import MenuPanel from 'src/components/MenuPanel.vue';
import { ref, computed } from 'vue';
import { useRouter } from 'vue-router';

const leftDrawerOpen = ref<boolean>(true);
const rightDrawerOpen = ref<boolean>(true);
const router = useRouter();

const userRole = ref<string>('Admin');

const isUser = computed(() => userRole.value === 'User');
const isPersonnel = computed(() => userRole.value === 'Personnel');
const isAdmin = computed(() => userRole.value === 'Admin');

interface ChildItem {
  label: string;
  url?: string;
}

interface MenuItem {
  label: string;
  icon: string;
  url?: string;
  children?: ChildItem[];
}

const menuItems = ref<MenuItem[]>([
  {
    label: 'Dashboard',
    icon: 'space_dashboard',
    url: '/profile',
  },
  {
    label: 'Room Management',
    icon: 'door_back',
    children: [
      { label: 'View rooms', url: '/view-rooms' },
      { label: 'Room request', url: '/room-request' },
      { label: 'View Requests', url: '/view-requests' },
    ],
  },
  {
    label: 'Maintenance Requests',
    icon: 'room_service',
    children: [
      { label: 'New maintenance request', url: '/new-maintenance-request' },
      { label: 'View requests', url: '/view-requests' },
      { label: 'View completed requests', url: '/view-completed-requests' },
    ],
  },
  {
    label: 'Settings',
    icon: 'settings',
    children: [
      { label: 'Update profile', url: '/update-profile' },
      { label: 'Change password', url: '/change-password' },
    ],
  },
  { label: 'Logout', icon: 'logout', url: '/logout' },
]);

const personnelMenuItems = ref<MenuItem[]>([
  {
    label: 'Room Management',
    icon: 'door_back',
    children: [
      { label: 'Management', url: '/management' },
      { label: 'Manage room bookings', url: '/manage-room-bookings' },
    ],
  },
  {
    label: 'Maintenance Management',
    icon: 'room_service',
    children: [
      { label: 'View All Requests', url: '/view-all-requests' },
      { label: 'Maintenance history', url: '/maintenance-history' },
    ],
  },
  {
    label: 'Analytics',
    icon: 'assessment',
    children: [
      { label: 'Room', url: '/analytics-room' },
      { label: 'Maintenance', url: '/analytics-maintenance' },
    ],
  },
  {
    label: 'User Management',
    icon: 'manage_accounts',
    url: '/user-management',
  },
  {
    label: 'Staff Management',
    icon: 'engineering',
    url: '/staff-management',
  },
  {
    label: 'Database',
    icon: 'storage',
    url: '/database',
  },
]);

const thumbStyle = ref({
  right: '4px',
  borderRadius: '5px',
  backgroundColor: '#7466F1',
  width: '5px',
  opacity: '0.75',
});

const barStyle = ref({
  right: '2px',
  borderRadius: '9px',
  backgroundColor: '#242332',
  width: '9px',
  opacity: '0.2',
});

const goToUserHelp = () => {
  router.push('/helpUser');
};

const goToPersonnelHelp = () => {
  router.push('/helpPersonnel');
};

const toggleLeftDrawer = () => {
  leftDrawerOpen.value = !leftDrawerOpen.value;
};

const toggleRightDrawer = () => {
  rightDrawerOpen.value = !rightDrawerOpen.value;
};
</script>
