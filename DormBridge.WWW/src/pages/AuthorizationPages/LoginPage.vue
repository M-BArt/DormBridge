<template>
  <q-layout>
    <q-page-container>
      <q-page class="flex flex-center column">
        <!-- Image -->
        <q-img src="/icons/DormBridge.png" alt="Logo" style="width: 250px; height: auto; cursor: default">
          <template v-slot:error>
            <div style="cursor: default">Cannot load image.</div>
          </template>
        </q-img>

        <h3 class="q-ma-none" style="color: white">DormBridge</h3>
        <div class="q-pa-md row items-start q-gutter-md">
          <q-card
            class="my-card inset-shadow-down shadow-10"
            style="width: 350px; background-color: #34415f; color: white"
          >
            <q-card-section class="q-gutter-lg">
              <q-input color="white" outlined v-model="text" label="Username or email" dark>
                <template v-slot:prepend>
                  <q-icon name="account_circle" color="white" text-color="white" />
                </template>
              </q-input>
              <q-input color="white" outlined v-model="text" label="Password" dark>
                <template v-slot:prepend>
                  <q-icon name="lock" color="white" />
                </template>
              </q-input>
            </q-card-section>
            <q-separator />
            <q-card-actions class="flex justify-evenly">
              <q-checkbox name="accept_agreement" v-model="acceptAgreement" label="Remember password" dark />
              <div class="q-pl-xl">
                <q-btn flat style="background: #21ba45" color="white">Sign in</q-btn>
              </div>
            </q-card-actions>
            <div class="q-pl-xl q-py-md q-gutter-md">
              <router-link to="/remind" style="color: white">Forgot your password?</router-link>
            </div>
            <q-separator />
            <q-card-actions vertical>
              <q-btn flat to="/register" tag="router-link">Sign up</q-btn>
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
const acceptAgreement = ref<string>('');
</script>
