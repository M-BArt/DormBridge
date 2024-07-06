<template>
  <q-layout view="lHr lpR lfr">
    <q-header elevated class="text-white asd q-ma-sm">
      <q-toolbar>
        <q-btn dense flat round icon="menu" @click="toggleLeftDrawer" />
        <q-icon class="q-mr-sm" name="help_outline" size="2em" />
        <q-toolbar-title class="flex flex-center"> <p class="text-subtitle1 q-ma-none">Admin Account</p> </q-toolbar-title>
        <q-icon @click="goToHelp" class="q-mr-sm" name="help_outline" size="2em" />
        <q-icon class="q-mr-sm" name="notifications_none" size="2em" />
        <q-avatar class="q-ma-none" size="35px">
          <img src="/icons/User.png" />
        </q-avatar>
        <q-btn dense flat round icon="menu" @click="toggleRightDrawer" />
      </q-toolbar>
    </q-header>

    <q-drawer :width="325" show-if-above v-model="leftDrawerOpen" side="left" class="asd flex justify-center items-center">
      <q-card class="asd flex flex-center no-shadow self-start">
        <q-card class="asd flex flex-center justify-evently no-shadow q-pa-none q-mt-md" style="width: 100%">
          <img style="width: 65px" src="/icons/DormBridge.png" />
          <h4 class="q-pa-none q-ma-md" style="color: white">DormBridge</h4>
        </q-card>
        <q-scroll-area :thumb-style="thumbStyle" :bar-style="barStyle" style="height: 70vh; width: 100%">
          <q-card class="q-ma-none q-mt-none q-pa-sm asd flex flex-center no-shadow">
            <q-list style="width: 100%">
              <q-item clickable @click="goToPage(item.url)" v-for="item in menuItems" :key="item.label" style="width: 100%">
                <q-expansion-item
                  v-if="item.children"
                  :label="item.label"
                  :icon="item.icon"
                  :style="{ color: activeItem === item.label && !activeSubItem ? '#7466F1' : '#cbcbcb', width: '100%' }"
                >
                  <q-list>
                    <q-item
                      v-for="child in item.children"
                      :key="child.label"
                      @click.stop="setActiveSubItem(child.label)"
                      :class="{ 'active-sub-item': activeSubItem === child.label }"
                      clickable
                    >
                      <q-item-section>
                        {{ child.label }}
                      </q-item-section>
                    </q-item>
                  </q-list>
                </q-expansion-item>

                <q-btn
                  v-else
                  :style="{ color: activeItem === item.label ? '#7466F1' : '#cbcbcb', width: '100%' }"
                  align="left"
                  flat
                  :label="item.label"
                  :icon="item.icon"
                  @click="setActive(item.label)"
                />
              </q-item>
            </q-list>
          </q-card>
        </q-scroll-area>
      </q-card>

      <q-card class="asd flex flex-center no-shadow self-end">
        <p style="color: white">© 2024 DormBridge. All rights reserved.</p>
        <p style="color: white">Designed by Bartosz Mroczkowski</p>
      </q-card>
    </q-drawer>

    <q-drawer :width="325" show-if-above v-model="rightDrawerOpen" side="right" class="asd flex justify-center items-center">
      <q-card class="asd flex flex-center no-shadow self-start">
        <q-card class="asd flex flex-center justify-evently no-shadow q-pa-none q-mt-md" style="width: 100%">
          <h4 class="q-pa-none q-ma-md" style="color: white">Personnel Panel</h4>
        </q-card>
        <q-scroll-area :thumb-style="thumbStyle" :bar-style="barStyle" style="height: 70vh; width: 100%">
          <q-card class="q-ma-none q-mt-none q-pa-sm asd flex flex-center no-shadow">
            <q-list style="width: 100%">
              <q-item clickable @click="goToPage(item.url)" v-for="item in personnelMenuItems" :key="item.label" style="width: 100%">
                <q-expansion-item
                  v-if="item.children"
                  :label="item.label"
                  :icon="item.icon"
                  :style="{ color: activeItem === item.label && !activeSubItem ? '#7466F1' : '#cbcbcb', width: '100%' }"
                >
                  <q-list>
                    <q-item
                      v-for="child in item.children"
                      :key="child.label"
                      @click.stop="setActiveSubItem(child.label)"
                      :class="{ 'active-sub-item': activeSubItem === child.label }"
                      clickable
                    >
                      <q-item-section>
                        {{ child.label }}
                      </q-item-section>
                    </q-item>
                  </q-list>
                </q-expansion-item>

                <q-btn
                  v-else
                  :style="{ color: activeItem === item.label ? '#7466F1' : '#cbcbcb', width: '100%' }"
                  align="left"
                  flat
                  :label="item.label"
                  :icon="item.icon"
                  @click="setActive(item.label)"
                />
              </q-item>
            </q-list>
          </q-card>
        </q-scroll-area>
      </q-card>
    </q-drawer>

    <q-page-container class="q-ma-none q-pa-none">
      <router-view />
    </q-page-container>
  </q-layout>
</template>

<script>
export default {
  data() {
    return {
      thumbStyle: {
        right: '4px',
        borderRadius: '5px',
        backgroundColor: '#7466F1',
        width: '5px',
        opacity: 0.75,
      },

      barStyle: {
        right: '2px',
        borderRadius: '9px',
        backgroundColor: '#242332',
        width: '9px',
        opacity: 0.2,
      },
      activeItem: null,
      activeSubItem: null,
      leftDrawerOpen: true,
      rightDrawerOpen: true,
      menuItems: [
        {
          label: 'Dashboard',
          icon: 'space_dashboard',
          url: '/profile',
        },
        { label: 'Room Management', icon: 'door_back', children: [{ label: 'View rooms' }, { label: 'Room request' }, { label: 'View Requests' }] },
        {
          label: 'Maintenance Requests',
          icon: 'room_service',
          children: [{ label: 'New maintenance request' }, { label: 'View requests' }, { label: 'View completed requests' }],
        },
        {
          label: 'Settings',
          icon: 'settings',
          children: [{ label: 'Update profile' }, { label: 'Change password' }],
        },
        { label: 'Logout', icon: 'logout' },
      ],
      personnelMenuItems: [
        {
          label: 'Room Management',
          icon: 'door_back',
          children: [{ label: 'Management' }, { label: 'Manage room bookings' }],
        },
        {
          label: 'Maintenance Management',
          icon: 'room_service',
          children: [{ label: 'View All Requests' }, { label: 'Maintenance history' }],
        },
        {
          label: 'Analytics',
          icon: 'assessment',
          children: [{ label: 'Room' }, { label: 'Maintenance' }],
        },
        {
          label: 'User Management',
          icon: 'manage_accounts',
        },
        {
          label: 'Staff Management',
          icon: 'engineering',
        },
        { label: 'Database', icon: 'storage' },
      ],
    };
  },
  methods: {
    goToHelp() {
      this.$router.push('/login');
    },
    goToPage(url) {
      if (url) {
        this.$router.push(url);
      }
    },
    setActive(label) {
      this.activeItem = label;
      this.activeSubItem = null;
    },
    setActiveSubItem(label) {
      this.activeSubItem = label;
      this.activeItem = null;
    },
    toggleLeftDrawer() {
      this.leftDrawerOpen = !this.leftDrawerOpen;
    },
    toggleRightDrawer() {
      this.rightDrawerOpen = !this.rightDrawerOpen;
    },
  },
};
</script>

<style>
.q-btn {
  transition: background-color 0.3s ease;
}

.q-btn:hover {
  background-color: rgba(255, 255, 255, 0.1);
}

.q-btn:focus {
  background-color: rgba(255, 255, 255, 0.2);
}

.q-item {
  transition: background-color 0.3s ease;
}

.active-sub-item {
  color: #7466f1 !important;
}
</style>
