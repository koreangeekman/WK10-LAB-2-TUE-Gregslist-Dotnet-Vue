<template>
  <div class="home d-flex align-items-center justify-content-center p-0 m-0">
    <img src="https://user-images.githubusercontent.com/102513373/208978485-ee3a19b6-ebd8-4745-b0a2-7e509552146c.png"
      alt="Gregslist Logo" class="rounded-circle">
  </div>
</template>

<script>
export default {
  setup() {
    return {}
  }
}
</script>

<style scoped lang="scss">
.home {
  background-color: #123456;
  place-content: center;
  user-select: none;
  height: 90.1dvh;

  >img {
    object-fit: contain;
    object-position: center;
  }
}
</style>
