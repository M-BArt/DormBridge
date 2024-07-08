<template>
  <div>
    <HelpCards :helpCards="helpPersonnelCards" />
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import HelpCards from '../../components/HelpCards.vue';

interface HelpCard {
  title: string;
  icon: string;
  description: string;
}

const helpPersonnelCards = ref<HelpCard[]>([
  { title: 'Room Management', icon: 'door_back', description: '' },
  {
    title: 'Manage room bookings',
    icon: 'door_back',
    description: '',
  },
  {
    title: 'View All Requests',
    icon: 'room_service',
    description: '',
  },
  {
    title: 'Maintenance history',
    icon: 'room_service',
    description: '',
  },
  {
    title: 'Room Analytics',
    icon: 'assessment',
    description: '',
  },
  { title: 'Maintenance Analytics', icon: 'assessment', description: '' },
]);
</script>
