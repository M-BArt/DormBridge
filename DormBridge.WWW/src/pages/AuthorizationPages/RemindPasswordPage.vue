<template>
  <q-layout>
    <q-page-container>
      <q-page class="flex flex-center column">
        <q-img src="/icons/DormBridge.png" alt="Logo" style="width: 250px; height: auto; cursor: default">
          <template v-slot:error>
            <div style="cursor: default">Nie można załadować obrazu</div>
          </template>
        </q-img>
        <h3 class="q-ma-none text" style="color: white">DormBridge</h3>
        <div class="q-pa-md row items-start q-gutter-md">
          <q-card
            class="my-card inset-shadow-down shadow-10"
            style="width: 350px; background-color: #34415f; color: white"
          >
            <div class="flex flex-center">
              <h4 class="q-ma-md">Forgot your password?</h4>
              <p>Simply provide us with your email.</p>
            </div>
            <q-separator />
            <q-card-section class="q-gutter-lg">
              <!-- Email Input -->
              <q-input dark v-model="text" label="Email" color="white">
                <template v-slot:prepend>
                  <q-icon name="email" />
                </template>
              </q-input>
            </q-card-section>

            <q-separator />

            <!-- Button -->
            <q-card-actions class="flex justify-evenly">
              <div>
                <router-link to="/login" style="color: white"> Back to login</router-link>
              </div>

              <q-btn flat style="background: #21ba45">Remind Password</q-btn>
            </q-card-actions>
          </q-card>
        </div>
      </q-page>
    </q-page-container>
  </q-layout>
</template>

<script setup lang="ts">
import { ref } from 'vue';

const text = ref<string>('');
</script>
