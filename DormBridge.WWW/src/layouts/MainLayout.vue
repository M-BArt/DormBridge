<template>
  <q-layout view="lhh lpR fff">
    <q-header elevated class="text-white asd q-ma-sm">
      <q-toolbar>
        <q-btn dense flat round icon="menu" @click="toggleLeftDrawer" />
        <q-toolbar-title class="flex flex-center"> <p class="text-subtitle1 q-ma-none">Student Account</p> </q-toolbar-title>
        <q-icon class="q-mr-sm" name="notifications_none" size="2em" />

        <q-avatar class="q-ma-none" size="35px">
          <img src="/icons/User.png" />
        </q-avatar>
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
              <q-item v-for="item in menuItems" :key="item.label" style="width: 100%">
                <q-expansion-item
                  v-if="item.children"
                  :label="item.label"
                  :icon="item.icon"
                  :style="{ color: activeItem === item.label && !activeSubItem ? '#7466F1' : '#cbcbcb', width: '100%' }"
                  default-opened
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

    <q-page-container>
      <q-card class="zxc flex flex-cente q-pa-none q-ma-lg no-shadow">
        <q-card style="border-end-end-radius: 15px; height: 115px; width: 300px" class="q-ma-md q-mt-none asd">
          <q-card class="q-pa-none q-ma-none flex flex-center" style="background-color: #7466f1; color: white">
            <h6 class="q-pa-none q-ma-none">Dashboard</h6>
          </q-card>
        </q-card>

        <q-card style="border-end-end-radius: 15px; height: 115px; width: 300px" class="q-ma-md q-mt-none asd">
          <q-card class="q-pa-none q-ma-none flex flex-center" style="background-color: #7466f1; color: white">
            <h6 class="q-pa-none q-ma-none">View rooms</h6>
          </q-card>
        </q-card>
        <q-card style="border-end-end-radius: 15px; height: 115px; width: 300px" class="q-ma-md q-mt-none asd">
          <q-card class="q-pa-none q-ma-none flex flex-center" style="background-color: #7466f1; color: white">
            <h6 class="q-pa-none q-ma-none">Room request</h6>
          </q-card>
        </q-card>
        <q-card style="border-end-end-radius: 15px; height: 115px; width: 300px" class="q-ma-md q-mt-none asd">
          <q-card class="q-pa-none q-ma-none flex flex-center" style="background-color: #7466f1; color: white">
            <h6 class="q-pa-none q-ma-none">View room request</h6>
          </q-card>
        </q-card>

        <q-card style="border-end-end-radius: 15px; height: 115px; width: 300px" class="q-ma-md q-mt-none asd">
          <q-card class="q-pa-none q-ma-none flex flex-center" style="background-color: #7466f1; color: white">
            <h6 class="q-pa-none q-ma-none">New maintenance request</h6>
          </q-card>
        </q-card>
        <q-card style="border-end-end-radius: 15px; height: 115px; width: 300px" class="q-ma-md q-mt-none asd">
          <q-card class="q-pa-none q-ma-none flex flex-center" style="background-color: #7466f1; color: white">
            <h6 class="q-pa-none q-ma-none">View maintenance request</h6>
          </q-card>
        </q-card>
        <q-card style="border-end-end-radius: 15px; height: 115px; width: 300px" class="q-ma-md q-mt-none asd">
          <q-card class="q-pa-none q-ma-none flex flex-center" style="background-color: #7466f1; color: white">
            <h6 class="q-pa-none q-ma-none">View completed maintenance</h6>
          </q-card>
        </q-card>

        <q-card style="border-end-end-radius: 15px; height: 115px; width: 300px" class="q-ma-md q-mt-none asd">
          <q-card class="q-pa-none q-ma-none flex flex-center" style="background-color: #7466f1; color: white">
            <h6 class="q-pa-none q-ma-none">Update profile</h6>
          </q-card>
        </q-card>
        <q-card style="border-end-end-radius: 15px; height: 115px; width: 300px" class="q-ma-md q-mt-none asd">
          <q-card class="q-pa-none q-ma-none flex flex-center" style="background-color: #7466f1; color: white">
            <h6 class="q-pa-none q-ma-none">Change password</h6>
          </q-card>
        </q-card>
      </q-card>

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
      menuItems: [
        {
          label: 'Dashboard',
          icon: 'space_dashboard',
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
    };
  },
  methods: {
    setActive(label) {
      this.activeItem = label;
      this.activeSubItem = null; // Reset active sub-item when a main item is clicked
    },
    setActiveSubItem(label) {
      this.activeSubItem = label;
      this.activeItem = null; // Ensure activeItem is set to 'Dashboard' when a sub-item is clicked
    },
    toggleLeftDrawer() {
      this.leftDrawerOpen = !this.leftDrawerOpen;
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
