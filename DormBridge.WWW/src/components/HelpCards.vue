<template>
  <q-card class="zxc flex flex-center q-pa-none q-ma-md no-shadow">
    <q-scroll-area :thumb-style="thumbStyle" :bar-style="barStyle" style="height: 90vh; width: 100%">
      <q-card class="zxc flex flex-center q-pa-none q-ma-none no-shadow">
        <q-card
          v-for="item in helpCards"
          :key="item.title"
          style="border-end-end-radius: 15px; height: 115px; width: 300px"
          class="q-ma-md q-mt-none asd"
        >
          <q-card class="q-pa-none q-ma-none flex flex-center" style="height: 30%; width: 100%; background-color: #7466f1; color: white">
            <q-icon class="q-mr-sm" :name="item.icon" size="2em" />
            <h7 class="q-pa-none q-ma-none">{{ item.title }}</h7>
          </q-card>
          <q-card class="q-pa-sm q-ma-none flex flex-center" style="height: 70%; width: 100%; background-color: #2b2d41; color: white">
            <p>{{ item.description }}</p>
          </q-card>
        </q-card>
      </q-card>
    </q-scroll-area>
  </q-card>
</template>

<script setup lang="ts">
import { ref, defineProps } from 'vue';

interface HelpCard {
  title: string;
  icon: string;
  description: string;
}

defineProps<{
  helpCards: HelpCard[];
}>();

const thumbStyle = ref({
  right: '4px',
  borderRadius: '5px',
  backgroundColor: 'rgba(0,0,0,0.5)',
  width: '5px',
});

const barStyle = ref({
  right: '2px',
  borderRadius: '9px',
  backgroundColor: 'rgba(0,0,0,0.2)',
  width: '9px',
});
</script>

<style scoped>
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
