namespace GamesTan.Tutorial104 {
    public class ItemHeart : Item {
        public int count;
        protected override void OnTriggerTarget(Player player) {
            player.health += 30;
        }
    }
}