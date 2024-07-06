<template>
  <div>
    <HelpCards :helpCards="helpCards" />
    <!-- Reszta zawartości strony -->
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

const helpCards = ref<HelpCard[]>([
  {
    title: 'Dashboard',
    icon: 'space_dashboard',
    description: 'The main page where you can see an overview of all important information and notifications.',
  },
  {
    title: 'View rooms',
    icon: 'door_back',
    description: 'Browse available rooms to see detailed information about each one. Find the room that best suits your needs.',
  },
  {
    title: 'Room request',
    icon: 'door_back',
    description: 'Submit requests to reserve rooms for selected dates. Fill out the form to book the appropriate space for your event.',
  },
  { title: 'View room request', icon: 'door_back', description: 'Review your room reservation requests. Check the status of your submissions.' },
  {
    title: 'New maintenance request',
    icon: 'room_service',
    description: 'Submit new requests for maintenance or repairs. Describe the issue and send the request to receive technical assistance.',
  },
  {
    title: 'View maintenance request',
    icon: 'room_service',
    description: 'Browse current and maintenance requests. Monitor the status of your submissions.',
  },
  {
    title: 'View completed maintenance',
    icon: 'room_service',
    description: 'View a list of completed maintenance tasks. Check what repairs have been done and when they were completed.',
  },
  {
    title: 'Update profile',
    icon: 'settings',
    description: 'Update your personal information and user preferences. Ensure your profile is always up to date.',
  },
  { title: 'Change password', icon: 'settings', description: 'Update your account password to ensure your security.' },
]);
</script>
