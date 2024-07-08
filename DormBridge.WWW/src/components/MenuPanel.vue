<template>
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
              @click="goToPage(child.url)"
              v-for="child in item.children"
              :key="child.label"
              @click.stop="setActiveSubItem(child.label)"
              :class="{ 'active-sub-item': activeSubItem === child.label }"
              clickable
              :style="{ color: activeSubItem === child.label && !activeItem ? '#7466F1' : '#cbcbcb', width: '100%' }"
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
</template>

<script setup lang="ts">
import { ref, defineProps } from 'vue';
import { useRouter } from 'vue-router';

const activeItem = ref<string | null>(null);
const activeSubItem = ref<string | null>(null);
const router = useRouter();

interface MenuItem {
  label: string;
  icon: string;
  url?: string;
  children?: childItem[];
}

interface childItem {
  label: string;
  url?: string;
}

defineProps<{
  menuItems: MenuItem[];
}>();

const goToPage = (url: string | undefined) => {
  if (url) {
    router.push(url);
  }
};

const setActive = (label: string) => {
  activeItem.value = label;
  activeSubItem.value = null;
};

const setActiveSubItem = (label: string) => {
  activeSubItem.value = label;
  activeItem.value = null;
};
</script>
