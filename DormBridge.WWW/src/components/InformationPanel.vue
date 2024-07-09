<template>
  <q-card class="q-pa-sm asd" :style="{ width: cardWidth, border: '1px solid #7466f1' }">
    <q-list>
      <q-item-label header class="" style="color: #7466f1; font-size: 18px">{{ header }}</q-item-label>

      <q-item v-for="item in information" :key="item.label" class="q-pa-sm">
        <q-item-section>
          <q-item-label style="color: White">{{ item.label }}:</q-item-label>
        </q-item-section>

        <q-item-section side>
          <q-item-label style="color: White">{{ item.value }}</q-item-label>
        </q-item-section>
      </q-item>
    </q-list>
  </q-card>
</template>

<script setup lang="ts">
import { defineProps } from 'vue';

interface Information {
  label: string;
  value: string;
}

defineProps<{
  header: string;
  information: Information[];
  cardWidth: string;
}>();
</script>
