<template>
  <q-layout>
    <q-page-container>
      <q-page class="flex flex-center column">
        <div class="q-pa-md row items-start q-gutter-md">
          <q-card
            class="my-card inset-shadow-down shadow-10"
            style="width: 350px; background-color: #34415f; color: white"
          >
            <div class="flex flex-center">
              <h3 class="q-ma-md">Registration</h3>
              <p>Fill out the form carefully for registration</p>
            </div>
            <q-separator />
            <!-- Username Input -->
            <q-card-section class="q-gutter-lg">
              <q-input dark v-model="text" label="Username" color="white">
                <template v-slot:prepend>
                  <q-icon name="person" />
                </template>
              </q-input>
              <!-- Email Input -->
              <q-input dark v-model="text" label="Email" color="white">
                <template v-slot:prepend>
                  <q-icon name="email" />
                </template>
              </q-input>
              <!-- Password Input -->
              <q-input dark v-model="text" label="Password" color="white">
                <template v-slot:prepend>
                  <q-icon name="lock" />
                </template>
              </q-input>
              <!-- Confirm Password Input -->
              <q-input dark v-model="text" label="Confirm Password" color="white">
                <template v-slot:prepend>
                  <q-icon name="lock_reset" />
                </template>
              </q-input>
              <!-- Student ID Input -->
              <q-input dark v-model="text" label="Student ID" color="white">
                <template v-slot:prepend>
                  <q-icon name="fingerprint" />
                </template>
              </q-input>
            </q-card-section>

            <q-separator />

            <!-- Button -->
            <q-card-actions vertical>
              <q-btn flat style="background: #21ba45">Zarejestruj się</q-btn>
            </q-card-actions>

            <div class="flex flex-center q-pa-md">
              <p class="q-ma-none">Already have an account? &nbsp;</p>
              <div></div>
              <router-link to="/login" style="color: green"> Sign in.</router-link>
            </div>
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
