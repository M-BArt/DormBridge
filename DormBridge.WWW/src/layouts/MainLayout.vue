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

    <!-- Left Drawer for Users-->
    <q-drawer :width="325" show-if-above v-model="leftDrawerOpen" side="left" class="asd flex justify-center items-center" v-if="isUser">
      <q-card class="asd flex flex-center no-shadow self-start">
        <q-card class="asd flex flex-center justify-evently no-shadow q-pa-none q-mt-md" style="width: 100%">
          <img style="width: 65px" src="/icons/DormBridge.png" />
          <h4 class="q-pa-none q-ma-md" style="color: white">DormBridge</h4>
        </q-card>
        <q-scroll-area :thumb-style="thumbStyle" :bar-style="barStyle" style="height: 55vh; width: 100%">
          <MenuPanel :menuItems="menuItems" />
        </q-scroll-area>
      </q-card>

      <q-card class="asd column q-ma-md flex flex-center no-shadow self-end">
        <p style="color: white">Your account is not activated?</p>
        <p style="color: white">Activate your student account</p>
        <q-btn flat style="background: #21ba45" color="white" @click="showFormDialog = true">Activate</q-btn>
      </q-card>

      <!-- Form Dialog -->
      <q-dialog v-model="showFormDialog" persistent>
        <q-card dark class="asd no-shadow" style="min-width: 350px">
          <q-card-section>
            <div class="text-h6">Activate student account</div>
          </q-card-section>

          <q-card-section class="q-pt-none">
            <q-form @submit="submitForm">
              <q-input color="white" dark v-model="formData.name" label="Student Album" />
              <q-card-actions align="right">
                <q-btn flat label="Cancel" @click="showFormDialog = false" />
                <q-btn flat type="submit" style="background: #21ba45" color="white">Activate</q-btn>
              </q-card-actions>
            </q-form>
          </q-card-section>
        </q-card>
      </q-dialog>

      <q-card class="asd flex flex-center no-shadow self-end">
        <p style="color: white">© 2024 DormBridge. All rights reserved.</p>
        <p style="color: white">Designed by Bartosz Mroczkowski</p>
      </q-card>
    </q-drawer>

    <!-- Left Drawer for Students and Admin -->
    <q-drawer
      :width="325"
      show-if-above
      v-model="leftDrawerOpen"
      side="left"
      class="asd flex justify-center items-center"
      v-if="isStudent || isAdmin"
    >
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
      <q-card class="zxc flex flex-center q-pa-none q-ma-sm q-mt-md no-shadow">
        <q-scroll-area :thumb-style="thumbStyle" :bar-style="barStyle" style="height: 90vh; width: 100%">
          <router-view />
        </q-scroll-area>
      </q-card>
    </q-page-container>
  </q-layout>
</template>

<script setup lang="ts">
import MenuPanel from 'src/components/MenuPanel.vue';
import { ref, computed } from 'vue';
import { useRouter } from 'vue-router';

const leftDrawerOpen = ref<boolean>(true);
const rightDrawerOpen = ref<boolean>(true);
const showFormDialog = ref<boolean>(false);
const router = useRouter();

const userRole = ref<string>('User');

const isUser = computed(() => userRole.value === 'User');
const isStudent = computed(() => userRole.value === 'Student');
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
    url: '/dashboard',
  },
  {
    label: 'Room Management',
    icon: 'door_back',
    children: [
      { label: 'View rooms', url: '/view-rooms' },
      { label: 'Room request', url: '/room-request' },
      { label: 'View Requests', url: '/view-requests-room' },
    ],
  },
  {
    label: 'Maintenance Requests',
    icon: 'room_service',
    children: [
      { label: 'New maintenance request', url: '/new-maintenance-request' },
      { label: 'View requests', url: '/view-requests-maintenance' },
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

const formData = ref({
  name: '',
  email: '',
  message: '',
});

const goToUserHelp = () => {
  router.push('/help-user');
};

const goToPersonnelHelp = () => {
  router.push('/help-personnel');
};

const toggleLeftDrawer = () => {
  leftDrawerOpen.value = !leftDrawerOpen.value;
};

const toggleRightDrawer = () => {
  rightDrawerOpen.value = !rightDrawerOpen.value;
};

const submitForm = () => {
  console.log('Form Data:', formData.value);
  showFormDialog.value = false;
};
</script>
