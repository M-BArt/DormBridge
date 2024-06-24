<template>
  <q-layout>
    <q-page-container>
      <q-page v-if="isLoading" class="flex flex-center">
        <q-img
          src="/icons/DormBridge.png"
          alt="Logo"
          style="width: 300px; height: auto; cursor: default"
          :class="{ 'blinking-image': isLoading }"
        >
          <template v-slot:error>
            <div style="cursor: default">Nie można załadować obrazu</div>
          </template>
        </q-img>
      </q-page>
      <q-page v-else>
        <router-view />
      </q-page>
    </q-page-container>
  </q-layout>
</template>

<script>
export default {
  data() {
    return {
      isLoading: true,
    };
  },
  mounted() {
    setTimeout(() => {
      this.isLoading = false;
      this.$router.push('/login');
    }, 5000);
  },
};
</script>

<style>
.blinking-image {
  animation: blinking 2s infinite;
}

@keyframes blinking {
  0%,
  100% {
    opacity: 1;
  }
  50% {
    opacity: 0;
  }
}
</style>
